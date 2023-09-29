import React, { useState } from "react";
import Modal from "react-bootstrap/Modal";
import Collapse from "react-bootstrap/Collapse";
import Button from "react-bootstrap/Button";

const AppointmentPopUp = (appointment) => {
  const [show, setShow] = useState(false);
  const [open, setOpen] = useState(false);

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
        scrollable={true}

        // fullscreen={true}
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
          <div className="container">
            <form className="mb-5">
              <label for="customer" className="form-label">
                Partner
              </label>
              <input type="text" className="form-control mb-2" id="customer" />
              <label for="patient" className="form-label">
                Dolgozó
              </label>
              <input type="text" className="form-control mb-2" id="patient" />
              <label for="job" className="form-label">
                Munkakör
              </label>
              <input type="text" className="form-control mb-2" id="job" />
              <label for="examinationType" className="form-label">
                Vizsgálat típusa
              </label>
              <input
                type="text"
                className="form-control mb-2"
                id="examinationType"
              />
              <label for="comment" className="form-label">
                Megjegyzés
              </label>
              <input type="text" className="form-control mb-2" id="comment" />
              <button className="btn btn-secondary">Mentés</button>
            </form>
          </div>

          <hr />
          <div className="bg-light ">
            <Button
              onClick={() => setOpen(!open)}
              aria-controls="example-collapse-text"
              aria-expanded={open}
            >
              Vizsgálat rögzítése
            </Button>
            <Collapse in={open}>
              <div id="example-collapse-text" className="bg-light">
                Anim pariatur cliche reprehenderit, enim eiusmod high life
                accusamus terry richardson ad squid. Nihil anim keffiyeh
                helvetica, craft beer labore wes anderson cred nesciunt sapiente
                ea proident.
              </div>
            </Collapse>
          </div>
        </Modal.Body>
        <Modal.Footer>footer</Modal.Footer>
      </Modal>
    </div>
  );
};

export default AppointmentPopUp;
