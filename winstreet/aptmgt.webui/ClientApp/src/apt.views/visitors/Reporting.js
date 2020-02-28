import React, { useEffect, useContext, useState } from "react";
import MaterialTable from "material-table";
import { makeStyles } from "@material-ui/core/styles";
import { UserContext } from "store/UserContext";
import API from "apt.utils/API.js";
import authService from 'components/Authorization/AuthorizeService.js';

const styles = {
    cardCategoryWhite: {
        "&,& a,& a:hover,& a:focus": {
            color: "rgba(255,255,255,.62)",
            margin: "0",
            fontSize: "14px",
            marginTop: "0",
            marginBottom: "0"
        },
        "& a,& a:hover,& a:focus": {
            color: "#FFFFFF"
        }
    },
    cardTitleWhite: {
        color: "#FFFFFF",
        marginTop: "0px",
        minHeight: "auto",
        fontWeight: "300",
        fontFamily: "'Roboto', 'Helvetica', 'Arial', sans-serif",
        marginBottom: "3px",
        textDecoration: "none",
        "& small": {
            color: "#777",
            fontSize: "65%",
            fontWeight: "400",
            lineHeight: "1"
        }
    }
};

const useStyles = makeStyles(styles);
export default function Reporting() {

    const { communityid, setCommunityID } = useContext(UserContext);

    const columns = [
        { title: 'Visitor Name', field: 'visitorname', editable: 'never', type: 'text' },
        { title: 'Visitor Phone', field: 'visitorphone', editable: 'never', type: 'text' },
        { title: 'Host Name', field: 'hostname', editable: 'never', type: 'text' },
        { title: 'Host Phone', field: 'hostphone', editable: 'never', type: 'text' },
        { title: 'Checkin time', field: 'checkintime', editable: 'never', type: 'text' },
        { title: 'CheckOut time', field: 'checkouttime', type: 'text' },
    ];

    const [data, setData] = useState([]);


    useEffect(() => {
        async function loadVisitorList(commid) {
            const token = await authService.getAccessToken();
            await API.get('/Visitors/GetAllVisitor', {
                params: {
                    communityID: commid
                },
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        visitorname: value.name,
                        visitorphone: value.phone,
                        hostname: value.hostName,
                        hostphone: value.hostPhone,
                        checkintime: value.checkinDate,
                        checkouttime: value.checkOutDate,
                        visitid: value.visitID
                    };
                    dataRows.push(obj);
                });
                setData(dataRows);
            });
        }

        //Execute the created function directly
        if (!communityid) {
            alert("Please select community ID.")
        } else {
            loadVisitorList(communityid);
        }

    }, []); 

    return (
        <MaterialTable
            title=""
            columns={columns}
            data={data}
            options={{
                filtering: true,
                exportButton: true
            }}
        />
    );
}