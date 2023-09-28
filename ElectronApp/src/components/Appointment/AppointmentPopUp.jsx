import React, { useState } from "react";
import Modal from "react-bootstrap/Modal";

const AppointmentPopUp = (appointment) => {
  const [show, setShow] = useState(false);

  console.log(` Ez jön át: ${appointment.appointment.id}`);
  const handleShow = () => setShow(true);
  const handleClose = () => setShow(false);

  const weekdayCalculator = (date) => {
    const weekday = [
      "vasárnap",
      "hétfő",
      "kedd",
      "szerda",
      "csütörtök",
      "péntek",
      "szombat",
    ];
    const d = new Date(date);
    return weekday[d.getDay()];
  };

  return (
    <div className="container">
      <button
        className="btn btn-primary"
        variant="primary"
        onClick={handleShow}
      >
        {appointment.appointment.surgeryName}
      </button>
      <Modal
        show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}
        fullscreen={true}
      >
        <Modal.Header closeButton>
          <Modal.Title style={{ width: "100vw" }}>
            <div className="container">
              <div className="row">
                <div className="col col-4">
                  <h3>{appointment.appointment.surgeryName}</h3>
                </div>
                <div className="col col-4">
                  <h3>
                    {appointment.appointment.dateTime.slice(0, 10)},{" "}
                    {weekdayCalculator(
                      appointment.appointment.dateTime.slice(0, 10)
                    )}
                  </h3>
                </div>
                <div className="col col-4">
                  <h3>{appointment.appointment.dateTime.slice(11, 16)}</h3>
                </div>
              </div>
            </div>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>még több részlet</p>
        </Modal.Body>
        <Modal.Footer>footer</Modal.Footer>
      </Modal>
    </div>
  );
};

export default AppointmentPopUp;
