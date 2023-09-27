import React from "react";
import { useEffect, useState } from "react";

const AppointmentView = () => {
  const [appointments, setAppointments] = useState([]);
  const [originalList, setOriginalList] = useState([]);

  // GET data from WEB API
  useEffect(() => {
    async function getApi() {
      let response = JSON.parse(await window.indexBridge.fetchApi());
      setOriginalList(response);
      const filteredList = response.filter((appointment) => {
        return appointment.surgery.name === dropDown;
      });

      setAppointments(filteredList);
    }

    getApi();
  }, []);

  // Populate dropdown menu

  const options = [
    { value: "", text: "" },
    { value: "Eger", text: "Eger" },
    { value: "Füzesabony", text: "Füzesabony" },
    { value: "Kápolna", text: "Kápolna" },
    { value: "Sirok", text: "Sirok" },
  ];

  const [dropDown, setDropDown] = useState(options[0].value);
  const [date, setDate] = useState("");

  const dropdownChange = (event) => {
    console.log(event.target.value);
    setDropDown(event.target.value);
    console.log(`original: ${originalList}`);
  };

  const dateChange = (event) => {
    console.log(event.target.value);
    setDate(event.target.value);
  };

  useEffect(() => {
    console.log(`dropdown: ${dropDown}`);
    console.log(`appointments: ${appointments}`);
    const filteredList = originalList.filter((appointment) => {
      return (
        appointment.surgery.name === dropDown &&
        appointment.dateTime.slice(0, 10) === date
      );
    });
    console.log(filteredList);

    setAppointments(filteredList);
  }, [dropDown, date]);

  return (
    <div className="container-fluid">
      <h1 className="mt-5 mb-2 text-primary">Előjegyzés</h1>
      <div
        className="container-fluid bg-gradient text-dark"
        style={{ background: "rgb(178, 235, 241  )" }}
      >
        <div className="row align-items-center">
          <div className="col-md-1">
            <p className="m-1">Rendelő</p>
          </div>
          <div className="col-md-2">
            <select
              value={dropDown}
              onChange={dropdownChange}
              style={{ border: "none" }}
            >
              {options.map((option) => (
                <option key={option.value} value={option.value}>
                  {option.text}
                </option>
              ))}
            </select>
          </div>
          <div className="col-md-1">
            <p className="m-1">Dátum</p>
          </div>
          <div className="col-md-1">
            <input
              onChange={dateChange}
              className="m-1"
              type="date"
              style={{ border: "none" }}
            />
          </div>
        </div>
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
                  <td>{appointment.dateTime.slice(11, 16)}</td>

                  {appointment.customer === null ? (
                    <td></td>
                  ) : (
                    <td>{appointment.customer.name}</td>
                  )}

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
