import React, { Component, useState } from "react";
import { Calendar, momentLocalizer } from "react-big-calendar";
import moment from "moment";
import Dialog from "@material-ui/core/Dialog";
import FlatButton from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import TimePicker from "@material-ui/pickers/TimePicker";

import GridContainer from "components/Grid/GridContainer.js";
import GridItem from "components/Grid/GridItem.js";

//BigCalendar.momentLocalizer(moment);
const localizer = momentLocalizer(moment)
const events = [{
    id: 0,
    title: 'All Day Event very long title',
    allDay: true,
    start: new Date(2019, 1, 1),
    end: new Date(2019, 2, 1),
},
{
    id: 1,
    title: 'Long Event',
    start: new Date(2015, 3, 7),
    end: new Date(2015, 3, 10),
},
]



export default function FacilityBooking() {

    const [events, setEvents] = useState([]);
    const [title, setTitle] = useState('');
    const [start, setStart] = useState('');
    const [end, setEnd] = useState('');
    const [desc, setDesc] = useState('');
    const [openSlot, setOpenSlot] = useState(false);
    const [openEvent, setOpenEvent] = useState(false);
    const [clickedEvent, setClickedEvent] = useState({});


    function handleClose() {
        setOpenEvent(false);
        setOpenSlot(false);
    }

    function handleEventSelected(e) {
        console.log("event", e);
        setOpenEvent(true);
        setClickedEvent(e);
        setStart(e.start);
        setEnd(e.end);
        setDesc(e.desc);
        setTitle(e.title);
    }

    function handleSlotSelected(slotInfo) {
        console.log("Real slotInfo", slotInfo);
        //setOpenSlot('true');
        setStart(slotInfo.start);
        setEnd(slotInfo.end);
        setDesc("");
        setTitle("");
    }


    function handleStartTime(date) {
        console.log("date", date);
        setStart(date);
    };

    function handleEndTime(date) {
        setEnd(date);
    };

    // Onclick callback function that pushes new appointment into events array.
    const setNewAppointment = () => {
        let appointment = { title, start, end, desc };
        let events = events.slice();
        events.push(appointment);
        // localStorage.setItem("cachedEvents", JSON.stringify(events));
        setEvents(events);
    }

    //  Updates Existing Appointments Title and/or Description
    const updateEvent = () => {
        const index = events.findIndex(event => event === clickedEvent);
        const updatedEvent = events.slice();
        updatedEvent[index].title = title;
        updatedEvent[index].desc = desc;
        updatedEvent[index].start = start;
        updatedEvent[index].end = end;
        // localStorage.setItem("cachedEvents", JSON.stringify(updatedEvent));
        setEvents(updatedEvent);
    }

    //  filters out specific event that is to be deleted and set that variable to state
    const deleteEvent = () => {
        let updatedEvents = events.filter(
            event => event["start"] !== start
        );
        // localStorage.setItem("cachedEvents", JSON.stringify(updatedEvents));
        setEvents(updatedEvents);
    }

    const eventActions = [
        <FlatButton
            label="Cancel"
            primary={false}
            keyboardFocused={true}
            onClick={handleClose}
        />,
        <FlatButton
            label="Delete"
            secondary={true}
            keyboardFocused={true}
            onClick={() => {
                deleteEvent(), handleClose();
            }}
        />,
        <FlatButton
            label="Confirm Edit"
            primary={true}
            keyboardFocused={true}
            onClick={handleClose}
            onClick={() => {
                updateEvent(), handleClose();
            }}
        />
    ];
    const appointmentActions = [
        <FlatButton label="Cancel" secondary={true} onClick={handleClose} />,
        <FlatButton
            label="Submit"
            primary={true}
            keyboardFocused={true}
            onClick={() => {
                setNewAppointment(), handleClose();
            }}
        />
    ];


    return (
        <GridContainer>
            <GridItem xs={12} sm={12} md={12}>
                <Calendar
                    localizer={localizer}
                    events={events}
                    views={["month", "week", "day", "agenda"]}
                    timeslots={2}
                    culture='en-GB'
                    defaultView="week"
                    localizer={localizer}
                    defaultDate={new Date()}
                    selectable={true}
                    onSelectEvent={event => handleEventSelected(event)}
                    onSelectSlot={slotInfo => handleSlotSelected(slotInfo)}
                />

                {/* Material-ui Modal for booking new appointment */}
                <Dialog
                    title={`Book an appointment on ${moment(start).format(
                        "MMMM Do YYYY"
                    )}`}
                    actions={appointmentActions}
                    modal={false}
                    open={openSlot}
                    onRequestClose={handleClose}
                >
                    <TextField
                        floatingLabelText="Title"
                        onChange={e => {
                            setTitle(e.target.value);
                        }}
                    />
                    <br />
                    <TextField
                        floatingLabelText="Description"
                        onChange={e => {
                            setDesc(e.target.value);
                        }}
                    />
                    <TimePicker
                        //format="ampm"
                        //floatingLabelText="Start Time"
                        //minutesStep={5}
                        //value={start}
                        //onChange={() => handleStartTime(value)}
                    />
                    <TimePicker
                        //format="ampm"
                        //floatingLabelText="End Time"
                        //minutesStep={5}
                        //value={end}
                        //onChange={handleEndTime}
                    />
                </Dialog>

                {/* Material-ui Modal for Existing Event */}
                <Dialog
                    title={`View/Edit Appointment of ${moment(start).format(
                        "MMMM Do YYYY"
                    )}`}
                    actions={eventActions}
                    modal={false}
                    open={openEvent}
                    onRequestClose={handleClose}
                >
                    <TextField
                        defaultValue={title}
                        floatingLabelText="Title"
                        onChange={e => {
                            setTitle(e.target.value);
                        }}
                    />
                    <br />
                    <TextField
                        floatingLabelText="Description"
                        multiLine={true}
                        defaultValue={desc}
                        onChange={e => {
                            setDesc(e.target.value);
                        }}
                    />
                    <TimePicker
                        format="ampm"
                        floatingLabelText="Start Time"
                        minutesStep={5}
                        value={start}
                        onChange={handleStartTime}
                    />
                    <TimePicker
                        format="ampm"
                        floatingLabelText="End Time"
                        minutesStep={5}
                        value={end}
                        onChange={handleEndTime}
                    />
                </Dialog>

            </GridItem>
        </GridContainer>
    );
}
