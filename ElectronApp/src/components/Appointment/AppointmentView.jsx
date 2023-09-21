import React from "react";
import { useEffect, useState } from "react";

const AppointmentView = () => {
  const [appointments, setAppointments] = useState("");

  useEffect(() => {
    async function getApi() {
      let response = JSON.parse(await window.indexBridge.fetchApi());
      setAppointments(response);
    }

    getApi();
  }, []);

  return (
    <div className="container-fluid">
      <h1 className="mt-5 mb-2 text-primary">Előjegyzés</h1>
      <div className="container-fluid bg-light text-dark">
        <p className="p-3 mb-2 ">Időpontok szűrése</p>
      </div>

      <table className="table table-hover table-responsive">
        <thead>
          <tr>
            <th>Rendelő</th>
            <th>Dátum</th>
            <th>Időpont</th>
            <th style={{ minWidth: "200px" }}>Partner</th>
            <th>Dolgozó</th>
            <th>Vizsgálat típusa</th>
            <th>Megjegyzés</th>
            <th>Orvos</th>
            <th>Asszisztens</th>
          </tr>
        </thead>
        <tbody>
          {appointments &&
            appointments.map((appointment) => {
              return (
                <tr key={appointment.id}>
                  <td>{appointment.surgery.name}</td>
                  <td>{appointment.dateTime.slice(0, 10)}</td>
                  <td>{appointment.dateTime.slice(12, 16)}</td>
                  <td>{appointment.customer}</td>
                  <td>{appointment.patientName}</td>
                  <td>{appointment.examinationTypes}</td>
                  <td>{appointment.comment}</td>
                  <td>{appointment.personnelAttending[0].Name}</td>
                  <td>{appointment.personnelAttending[1].Name}</td>
                </tr>
              );
            })}
        </tbody>
      </table>
    </div>
  );
};

export default AppointmentView;
