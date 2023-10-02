import React from "react";
import { useState, useEffect } from "react";
import PageTitle from "../Shared/PageTitle";

const ListPatientAppointments = () => {
  const [appointments, setAppointments] = useState([]);
  const [originalList, setOriginalList] = useState([]);
  const [search, setSearch] = useState("");

  // GET data from WEB API
  useEffect(() => {
    async function getApi() {
      let response = JSON.parse(await window.indexBridge.fetchApi());
      setOriginalList(response);
    }

    getApi();
  }, []);

  const searchPatient = (event) => {
    setSearch(event.target.value);
  };

  useEffect(() => {
    const filteredList = originalList.filter((appointment) => {
      return search.toLowerCase() === ""
        ? ""
        : appointment.patientName.toLowerCase().includes(search.toLowerCase());
    });

    setAppointments(filteredList);
  }, [search]);

  console.log(search);

  return (
    <div>
      <PageTitle title={"Páciens időpontjainak keresése"} />

      {/* SEARCH BAR SECTION */}

      <div className="bg-secondary">
        <div className="container-fluid  text-white">
          <div className="row align-items-center">
            <div className="col-md-2">
              <p className="m-2">Páciens kiválasztása</p>
            </div>
            <div className="col-md-2">
              <input
                type="text"
                className="form-control-sm p-1 m-2"
                onChange={searchPatient}
              ></input>
            </div>
          </div>
        </div>
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
                    <td>{appointment.surgeryName} </td>
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

export default ListPatientAppointments;
