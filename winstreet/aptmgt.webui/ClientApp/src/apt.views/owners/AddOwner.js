import React, { useState, useEffect, useRef, useContext } from "react";
import { makeStyles } from "@material-ui/core/styles";
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";
import ReactToPrint from 'react-to-print';
import ImageUploader from 'react-images-upload';

import CustomInput from "components/CustomInput/CustomInput.js";
import Button from "components/CustomButtons/Button.js";
import MenuItem from '@material-ui/core/MenuItem';

import API from "apt.utils/API.js";
import TextField from '@material-ui/core/TextField';
import authService from 'components/Authorization/AuthorizeService.js';

import avatar from "assets/img/faces/marc.jpg";
import CardAvatar from "components/Card/CardAvatar.js";
import { UserContext } from "store/UserContext";
import base64 from 'react-native-base64'

var QRCode = require('qrcode.react');

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
    }, container: {
        display: 'flex',
        flexWrap: 'wrap',
    },
    textField: {
        marginLeft: 1,
        marginRight: 1,
        width: 200,
    },
};

const useStyles = makeStyles(styles);
const OwnerTypeOptions = [
    {
        value: 'Owner',
        label: 'Owner',
    },
    {
        value: 'Co-Owner',
        label: 'Co-Owner',
    },
    {
        value: 'Owner Family Member',
        label: 'Owner Family Member',
    },
    {
        value: 'Rented',
        label: 'Rented',
    },
    {
        value: 'Rented Family Member',
        label: 'Rented Family Member',
    },
];
const MemberShipTypes = [
    {
        value: 'President',
        label: 'President',
    },
    {
        value: 'Vice Persident/Secretary',
        label: 'Vice Persident/Secretary',
    },
    {
        value: 'Working committee member',
        label: 'Working committee member',
    },
    {
        value: 'Tresasure',
        label: 'Tresasure',
    },
    {
        value: 'Community Member',
        label: 'Community Member',
    },
    {
        value: 'Not Applicable',
        label: 'Not Applicable',
    },
];
export default function AddOwner() {

    const { communityid, setCommunityID } = useContext(UserContext);
    const componentRef = useRef();

    const classes = useStyles();
    const [ownertype, setOwnerType] = React.useState('');
    const [memebershiptype, setMemberShipType] = React.useState('');

    const [communitylist, setCommunityList] = useState([]);
    const [blocklist, setBlockList] = useState([]);
    const [flatlist, setFlatList] = useState([]);

    const [firstname, setFirstName] = useState('');
    const [lastname, setLastName] = useState('');

    const [selectedcommunityid, setSelectedCommunityId] = useState('');
    const [selectedcommunityname, setSelectedCommunityName] = useState('');

    const [selectedblockname, setSelectedBlockName] = useState('');
    const [selectedblockid, setSelectedBlockId] = useState('');

    const [selectedflat, setSelectedFlat] = useState();
    const [selectedflatid, setSelectedFlatId] = useState();

    const [contactnumber, setContactNumber] = useState('');
    const [email, setEmail] = useState('');
    const [notes, setNotes] = useState('');
    const [qrtext, setQRText] = useState('');

    const [pictures, setPictures] = useState('');
    const [picturebyte, setPictureByte] = useState([]);

    const handleCommunityNameChange = async (event) => {
        setSelectedCommunityName(event.target.value);
        await setSelectedCommunityId(event.target.value)

        const token = await authService.getAccessToken();
        //Block Details
        await API.get('/Community', {
            params: {
                commID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    label: value.blockName,
                    value: value.commBlockID
                };
                dataRows.push(obj);
            });
            setBlockList(dataRows);
        });
    }

    const handleBlockChange = async (event) => {
        setSelectedBlockName(event.target.value);
        await setSelectedBlockId(event.target.value)

        // Make a request to get the list Blocks
        const token = await authService.getAccessToken();
        await API.get('/Flats', {
            params: {
                blockID: event.target.value
            },
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        }).then(({ data }) => {
            const dataRows = [];
            data.map(function (value, key) {
                let obj = {
                    value: value.flatID,
                    label: value.flatNumber
                };
                dataRows.push(obj);
            });
            setFlatList(dataRows);
        });
    }

    const handleFlatChange = async (event) => {
        setSelectedFlat(event.target.value);
        await setSelectedFlatId(event.target.value)
    }

    const saveUser = async (event) => { 
        const requestBody = JSON.stringify({
            FirstName: firstname,
            LastName: lastname,
            BlockID: selectedblockid,
            FlatNumber: selectedflatid,
            Occupied: true,
            Picture: pictures,
            MobileNumber: contactnumber,
            Email: email,
            QRText: firstname + lastname + selectedblockid + selectedflatid + contactnumber,
            Active: true,
            CommunityID: selectedcommunityid,
            OwnerType: ownertype,
            MemberShipType: memebershiptype,
            notes: notes
        });
        const token = await authService.getAccessToken();
        const config = {
            headers: {
                authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            }
        };

        await API.post('/Owner', requestBody, config)
            .then(communityData => { 
                setPictures(base64.decode(communityData.data.picture));
                setQRText(communityData.data.qrText)
            })
            .catch(function (response) {
                console.log(response);
            });

    }

    const handleChangeOwnerType = event => {
        setOwnerType(event.target.value);
    };

    const handleMemberShipType = event => {
        setMemberShipType(event.target.value);
    };

    const downloadQR = () => {
        const canvas = document.getElementById("123456");
        const pngUrl = canvas
            .toDataURL("image/png")
            .replace("image/png", "image/octet-stream");
        let downloadLink = document.createElement("a");
        downloadLink.href = pngUrl;
        downloadLink.download = firstname + lastname + ".png";
        document.body.appendChild(downloadLink);
        downloadLink.click();
        document.body.removeChild(downloadLink);
    };


    useEffect(() => {
        async function loadCommunityList(builderid) {
            const token = await authService.getAccessToken();
            await API.get('/Community/GetAllCommunities', {
                headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
            }).then(({ data }) => {
                const dataRows = [];
                data.map(function (value, key) {
                    let obj = {
                        value: value.commID,
                        label: value.name
                    };
                    dataRows.push(obj);
                });
                setCommunityList(dataRows);
            });
        }

        // Execute the created function directly
        loadCommunityList('all');
    }, []);

    const onDrop = (picture) => {
        const file = picture[0];

        var g = new Promise((resolve, reject) => {
            const reader = new FileReader();

            reader.onload = (event) => {
                resolve(event.target.result);
            };

            reader.onerror = (err) => {
                reject(err);
            };

            reader.readAsDataURL(file);
        }).then(result => {
            setPictures(result);
            setPictureByte(convertStringToByteArray(result));
        }
        );
    };

    const convertStringToByteArray = (str) => {
        String.prototype.encodeHex = function () {
        var bytes = [];
        for (var i = 0; i < this.length; ++i) {
         bytes.push(this.charCodeAt(i));
        }
        return bytes;
        };
       
        var byteArray = str.encodeHex();
        return byteArray
        };

    return (
        <GridContainer>
            <GridItem xs={12} sm={12} md={8}>
                <Card>
                    <CardHeader plain color="primary">
                        <h4 className={classes.cardTitleWhite}>
                            Add new owner
                        </h4>
                    </CardHeader>
                    <CardBody>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    required
                                    id="firstname"
                                    label="First Name"
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    helperText="Enter First Name"
                                    onChange={e => setFirstName(e.target.value)}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    required
                                    id="lastname"
                                    label="Last Name"
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    helperText="Enter Last Name"
                                    onChange={e => setLastName(e.target.value)}
                                />
                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={12}>
                                <TextField
                                    required
                                    id="communityname"
                                    select
                                    label="Community"
                                    value={selectedcommunityname}
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    helperText="Select Community"
                                    onChange={handleCommunityNameChange}
                                >
                                    {communitylist.map(option => (
                                        <MenuItem key={option.value} value={option.value}>
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    required
                                    id="blocknumber"
                                    select
                                    label="Block"
                                    value={selectedblockname}
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    helperText="Select Block"
                                    onChange={handleBlockChange}
                                >
                                    {blocklist.map(option => (
                                        <MenuItem key={option.value} value={option.value}>
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </GridItem>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    required
                                    id="flatnumber"
                                    select
                                    label="Flat"
                                    value={selectedflat}
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    helperText="Select Flat"
                                    onChange={handleFlatChange}
                                >
                                    {flatlist.map(option => (
                                        <MenuItem key={option.value} value={option.value}>
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    required
                                    id="contactnumber"
                                    label="Contact Number"
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    helperText="Enter Contact Number"
                                    onChange={e => setContactNumber(e.target.value)}
                                />
                            </GridItem>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    required
                                    id="email"
                                    label="Email"
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    helperText="Enter Email"
                                    onChange={e => setEmail(e.target.value)}
                                />
                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    id="occupancytype"
                                    select
                                    className={classes.textField}
                                    value={ownertype}
                                    onChange={handleChangeOwnerType}
                                    fullWidth
                                    helperText="Occupancy Type"
                                    margin="normal"
                                >
                                    {OwnerTypeOptions.map(option => (
                                        <MenuItem key={option.value} value={option.value}>
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </GridItem>
                            <GridItem xs={12} sm={12} md={6}>
                                <TextField
                                    id="membershiptypeid"
                                    select
                                    className={classes.textField}
                                    value={memebershiptype}
                                    onChange={handleMemberShipType}
                                    fullWidth
                                    helperText="Membership Type ID"
                                    margin="normal"
                                >
                                    {MemberShipTypes.map(option => (
                                        <MenuItem key={option.value} value={option.value}>
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>

                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={12}>
                                <TextField
                                    required
                                    id="notes"
                                    label="Notes"
                                    className={classes.textField}
                                    margin="normal"
                                    fullWidth
                                    multiline
                                    rowsMax="5"
                                    helperText="Enter Notes"
                                    onChange={e => setNotes(e.target.value)}
                                />
                            </GridItem>
                        </GridContainer>
                        <GridContainer>
                            <GridItem xs={12} sm={12} md={6}>
                                <ImageUploader
                                    withIcon={true}
                                    buttonText='Choose images'
                                    onChange={files => onDrop(files)}
                                    imgExtension={['.jpg', '.gif', '.png', '.gif']}
                                    maxFileSize={5242880}
                                />

                            </GridItem>
                        </GridContainer>
                    </CardBody>
                    <CardFooter chart>
                        {/*
                                    more of qr code generation
                                    https://medium.com/@zaran.56/how-to-generate-and-download-a-qr-code-image-in-react-a3e924a672f5
                                */}
                        <div>
                            <QRCode
                                id="123456"
                                value={qrtext}
                                includeMargin={true}
                            />
                            <a onClick={downloadQR}> Download QR </a>
                        </div>
                    </CardFooter>
                    <GridContainer>
                        <Button
                            color="primary"
                            round
                            onClick={() => saveUser()}>
                            Save
                        </Button>
                    </GridContainer>
                </Card>
            </GridItem>
            <GridItem xs={12} sm={12} md={4}>
                <Card profile ref={componentRef} >
                    <CardHeader>
                    </CardHeader>
                    <CardAvatar profile>
                        <a href="#pablo" onClick={e => e.preventDefault()}>
                            <img src={pictures} alt="..." />
                            {/* <img src={`data:image/jpeg;base64,${binary_data}`} /> */}
                        </a>
                    </CardAvatar>
                    <CardBody profile>
                        <h2 className={classes.cardCategory}>{firstname + " " + lastname}</h2>
                        <h5 className={classes.cardTitle}>{selectedflat}</h5>
                        <h5 className={classes.cardTitle}>{ownertype}</h5>
                        <h5 className={classes.cardTitle}>{contactnumber}</h5>
                    </CardBody>
                </Card>

                <ReactToPrint
                    trigger={() => <Button round>Print this out!</Button>}
                    content={() => componentRef.current}
                />
            </GridItem>
        </GridContainer>
    );
}