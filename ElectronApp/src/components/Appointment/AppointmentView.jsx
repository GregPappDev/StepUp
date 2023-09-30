import React from "react";
import { useEffect, useState } from "react";
import AppointmentPopUp from "./AppointmentPopUp";

const AppointmentView = () => {
  const [appointments, setAppointments] = useState([]);
  const [originalList, setOriginalList] = useState([]);

  // GET data from WEB API
  useEffect(() => {
    async function getApi() {
      let response = JSON.parse(await window.indexBridge.fetchApi());
      setOriginalList(response);
      const filteredList = response.filter((appointment) => {
        return appointment.surgeryName === dropDown;
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
        appointment.surgeryName === dropDown &&
        appointment.dateTime.slice(0, 10) === date
      );
    });
    console.log(filteredList);

    setAppointments(filteredList);
  }, [dropDown, date]);

  return (
    <div>
      {/* TITLE SECTION */}
      <div className="bg-primary">
        <div className="container-fluid">
          <h2 className="p-2 text-white m-0">Előjegyzés</h2>
        </div>
      </div>

      {/* SEARCH BAR SECTION */}
      <div className="bg-secondary">
        <div className="container-fluid  text-white">
          <div className="row align-items-center">
            <div className="col-md-1">
              <p className="m-2">Rendelő</p>
            </div>
            <div className="col-md-2">
              <select
                value={dropDown}
                onChange={dropdownChange}
                style={{ border: "none" }}
                className="m-2"
              >
                {options.map((option) => (
                  <option key={option.value} value={option.value}>
                    {option.text}
                  </option>
                ))}
              </select>
            </div>
            <div className="col-md-1">
              <p className="m-2">Dátum</p>
            </div>
            <div className="col-md-1">
              <input
                onChange={dateChange}
                className="m-2"
                type="date"
                style={{ border: "none" }}
              />
            </div>
          </div>
        </div>

        <div className="m-5 bg-white"></div>
      </div>

      {/* TABLE SECTION */}
      <div className="container-fluid">
        <table className="table table-hover table-responsive ">
          <thead>
            <tr>
              <th>Rendelő</th>
              <th>Dátum</th>
              <th>Időpont</th>
              <th style={{ minWidth: "200px" }}>Partner</th>
              <th>Dolgozó</th>
              <th>Vizsgálat</th>
              <th>Megjegyzés</th>
              <th>Orvos</th>
              <th>Asszisztens</th>
            </tr>
          </thead>
          <tbody>
            {appointments &&
              appointments.map((appointment) => {
                return (
                  <tr
                    key={appointment.id}
                    onClick={() => console.log("clickkk")}
                  >
                    <td>
                      <AppointmentPopUp appointment={appointment} />
                    </td>
                    <td>{appointment.dateTime.slice(0, 10)}</td>
                    <td>{appointment.dateTime.slice(11, 16)}</td>

                    {appointment.customerName === null ? (
                      <td></td>
                    ) : (
                      <td>{appointment.customerName}</td>
                    )}

                    <td>{appointment.patientName}</td>
                    {/*should iterate through examintaion type list*/}
                    <td>{appointment.examinationTypes}</td>
                    <td>{appointment.comment}</td>
                    {/*should find appropriate person based on employee type*/}
                    <td>{appointment.personnelAttending[0].name}</td>
                    <td>{appointment.personnelAttending[1].name}</td>
                  </tr>
                );
              })}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default AppointmentView;
