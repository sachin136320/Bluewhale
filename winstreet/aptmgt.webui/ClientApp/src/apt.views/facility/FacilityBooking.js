import React, { Component, useState } from "react";
import { Calendar, momentLocalizer } from "react-big-calendar";
import moment from "moment";
import Dialog from "@material-ui/core/Dialog";
import FlatButton from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import TimePicker from "@material-ui/pickers/TimePicker";

import GridContainer from "components/Grid/GridContainer.js";
import GridItem from "components/Grid/GridItem.js";

import Scheduler, {SchedulerData, ViewTypes, DATE_FORMAT} from 'react-big-scheduler';
//include `react-big-scheduler/lib/css/style.css` for styles, link it in html or import it here 
import 'react-big-scheduler/lib/css/style.css';

//BigCalendar.momentLocalizer(moment);
const localizer = momentLocalizer(moment)
/*const events = [{
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
]*/

//2. create the view model, put it in the props obj
let schedulerData = new SchedulerData(new moment().format(DATE_FORMAT), ViewTypes.Week);
//set locale moment to the schedulerData, if your locale isn't English. By default, Scheduler comes with English(en, United States).
//moment.locale('zh-cn');
schedulerData.setLocaleMoment(moment);
//set resources here or later
let resources = [
                    {
                       id: 'r0',
                       name: 'Resource0',
                       groupOnly: true
                    },
                    {
                       id: 'r1',
                       name: 'Resource1'
                    },
                    {
                       id: 'r2',
                       name: 'Resource2',
                       parentId: 'r0'
                    },
                    {
                       id: 'r3',
                       name: 'Resource3',
                       parentId: 'r4'
                    },
                    {
                       id: 'r4',
                       name: 'Resource4',
                       parentId: 'r2'
                    },
                ];
schedulerData.setResources(resources);
//set events here or later, 
//the event array should be sorted in ascending order by event.start property, otherwise there will be some rendering errors
let events = [
                {
                     id: 1,
                     start: '2017-12-18 09:30:00',
                     end: '2017-12-19 23:30:00',
                     resourceId: 'r1',
                     title: 'I am finished',
                     bgColor: '#D9D9D9'
                 }, 
                 {
                     id: 2,
                     start: '2017-12-18 12:30:00',
                     end: '2017-12-26 23:30:00',
                     resourceId: 'r2',
                     title: 'I am not resizable',
                     resizable: false
                 }, 
                 {
                     id: 3,
                     start: '2017-12-19 12:30:00',
                     end: '2017-12-20 23:30:00',
                     resourceId: 'r3',
                     title: 'I am not movable',
                     movable: false
                 }, 
                 {
                     id: 4,
                     start: '2017-12-19 14:30:00',
                     end: '2017-12-20 23:30:00',
                     resourceId: 'r1',
                     title: 'I am not start-resizable',
                     startResizable: false
                 }, 
                 {
                     id: 5,
                     start: '2017-12-19 15:30:00',
                     end: '2017-12-20 23:30:00',
                     resourceId: 'r2',
                     title: 'R2 has recurring tasks every week on Tuesday, Friday',
                     rrule: 'FREQ=WEEKLY;DTSTART=20171219T013000Z;BYDAY=TU,FR',
                     bgColor: '#f759ab'
                 }
             ];
schedulerData.setEvents(events);
 

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
                deleteEvent();
                handleClose();
            }}
        />,
        <FlatButton
            label="Confirm Edit"
            primary={true}
            keyboardFocused={true}
            onClick={handleClose}
            onClick={() => {
                updateEvent();
                handleClose();
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
                setNewAppointment();
                handleClose();
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
