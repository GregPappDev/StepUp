import React, { useState } from "react";
//import Popup from "reactjs-popup";
import "reactjs-popup/dist/index.css";
import Modal from "react-bootstrap/Modal";

const AppointmentPopUp = (surgery) => {
  const [show, setShow] = useState(false);

  console.log(surgery.surgery);
  const handleShow = () => setShow(true);
  const handleClose = () => setShow(false);

  return (
    /*     <Popup
      trigger={<button className="btn btn-primary m-1"> Foglalás</button>}
      modal
      nested
    >
      <div className="header"> Részletek {surgery.surgery}</div>
    </Popup> */
    <>
      <button
        className="btn btn-primary"
        variant="primary"
        onClick={handleShow}
      >
        foglalás
      </button>
      <Modal
        show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}
      >
        <Modal.Header closeButton>
          <Modal.Title>
            <h3>{surgery.surgery}</h3>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>még több részlet</p>
        </Modal.Body>
        <Modal.Footer>footer</Modal.Footer>
      </Modal>
    </>
  );
};

export default AppointmentPopUp;
