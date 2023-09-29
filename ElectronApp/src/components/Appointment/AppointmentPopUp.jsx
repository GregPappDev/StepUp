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
        <Modal.Header>
          <Modal.Title style={{ width: "100vw" }}>
            <div className="container">
              <div className="row">
                <div className="col ">
                  <h3 className="bg-primary p-2" style={{ color: "white" }}>
                    {appointment.appointment.surgeryName}
                  </h3>
                </div>
              </div>
              <div className="row">
                <div className="col text-primary">
                  {appointment.appointment.dateTime.slice(0, 10)},{" "}
                  {weekdayCalculator(
                    appointment.appointment.dateTime.slice(0, 10)
                  )}
                </div>
              </div>
              <div className="row">
                <div className="col text-primary">
                  <p>{appointment.appointment.dateTime.slice(11, 16)}</p>
                </div>
              </div>
            </div>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="container">
            <form className="mb-5">
              <div className="form-floating">
                <input
                  type="text"
                  className="form-control mb-2"
                  id="customer"
                />
                <label for="customer" className="form-label">
                  Partner
                </label>
              </div>

              <div className="form-floating">
                <input type="text" className="form-control mb-2" id="patient" />
                <label for="patient" className="form-label">
                  Dolgozó
                </label>
              </div>

              <div className="form-floating">
                <input type="text" className="form-control mb-2" id="job" />
                <label for="job" className="form-label">
                  Munkakör
                </label>
              </div>

              <div className="form-floating">
                <input
                  type="text"
                  className="form-control mb-2"
                  id="examinationType"
                />
                <label for="examinationType" className="form-label">
                  Vizsgálat típusa
                </label>
              </div>

              <div className="form-floating">
                <input type="text" className="form-control mb-2" id="comment" />
                <label for="comment" className="form-label">
                  Megjegyzés
                </label>
              </div>
            </form>
          </div>

          <hr />
          <div className="container bg-light ">
            <Button
              onClick={() => setOpen(!open)}
              aria-controls="example-collapse-text"
              aria-expanded={open}
              className="mb-2"
            >
              Vizsgálat rögzítése
            </Button>
            <Collapse in={open}>
              <div id="example-collapse-text" className="bg-light pb-2">
                <form className="mb-2 mt-2">
                  <div className="mb-2">
                    <input
                      type="checkbox"
                      className="form-check-input m-1"
                      id="attended"
                    />
                    <label for="attended" className="form-check-label">
                      Megjelent
                    </label>
                  </div>
                  <div className="form-floating">
                    <input
                      type="text"
                      className="form-control mb-2"
                      id="result"
                    />
                    <label for="result" className="form-label">
                      Eredmény
                    </label>
                  </div>
                  <div className="form-floating">
                    <input
                      type="text"
                      className="form-control mb-2"
                      id="placeOfInvoice"
                    />
                    <label for="placeOfInvoice" className="form-label">
                      Számlázás helye
                    </label>
                  </div>
                  <div className="form-floating">
                    <input
                      type="text"
                      className="form-control mb-2"
                      id="invoiceNumber"
                    />
                    <label for="invoiceNumber" className="form-label">
                      Számlaszám
                    </label>
                  </div>
                  <div className="form-floating">
                    <input
                      type="textarea"
                      className="form-control mb-2 disabled"
                      id="invoiceComment"
                    />
                    <label for="invoiceComment" className="form-label">
                      Számlázáshoz megjegyzés
                    </label>
                  </div>
                  <p>Díjak</p>
                  <div className="row">
                    <div className="col col-3">
                      <div className="form-floating">
                        <input
                          type="text"
                          className="form-control mb-2 disabled"
                          id="priceA"
                        />
                        <label for="priceA" className="form-label">
                          A
                        </label>
                      </div>
                    </div>
                    <div className="col col-3">
                      <div className="form-floating">
                        <input
                          type="text"
                          className="form-control mb-2 disabled"
                          id="priceB"
                        />
                        <label for="priceB" className="form-label">
                          B
                        </label>
                      </div>
                    </div>
                    <div className="col col-3">
                      <div className="form-floating">
                        <input
                          type="text"
                          className="form-control mb-2 disabled"
                          id="priceC"
                        />
                        <label for="priceC" className="form-label">
                          C
                        </label>
                      </div>
                    </div>
                    <div className="col col-3">
                      <div className="form-floating">
                        <input
                          type="text"
                          className="form-control mb-2 disabled"
                          id="priceD"
                        />
                        <label for="priceD" className="form-label">
                          D
                        </label>
                      </div>
                    </div>
                  </div>
                </form>
              </div>
            </Collapse>
          </div>
        </Modal.Body>
        <Modal.Footer>
          <button className="btn btn-success">Mentés</button>
          <button className="btn btn-danger" onClick={handleClose}>
            Kilépés
          </button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default AppointmentPopUp;