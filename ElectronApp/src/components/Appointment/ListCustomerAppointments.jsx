import React from "react";
import { useState, useEffect } from "react";
import PageTitle from "../Shared/PageTitle";

const ListCustomerAppointments = () => {
  const [dropDown, setDropDown] = useState("");
  const [customerList, setCustomerList] = useState([]);
  const [originalList, setOriginalList] = useState([]);
  const [appointments, setAppointments] = useState([]);
  const [selection, setSelection] = useState("");

  useEffect(() => {
    async function getApi() {
      let customers = JSON.parse(await window.indexBridge.fetchCustomers());
      setCustomerList(customers.data);
      let response = JSON.parse(await window.indexBridge.fetchApi());
      setOriginalList(response);
    }

    getApi();
  }, []);

  const dropdownChange = (event) => {
    setDropDown(event.target.value);
    setSelection(event.target.value);
  };

  useEffect(() => {
    const filteredList = originalList
      .filter((appointment) => appointment.customerName === selection)
      .sort((a1, a2) =>
        a1.dateTime < a2.dateTime ? 1 : a1.dateTime > a2.dateTime ? -1 : 0
      );
    setAppointments(filteredList);
    console.log(selection);
  }, [selection]);

  return (
    <div>
      <PageTitle title={"Partner időpontjainak keresése"} />

      {/* SEARCH BAR SECTION */}
      <div className="bg-secondary">
        <div className="container-fluid  text-white">
          <div className="row align-items-center">
            <div className="col-md-2">
              <p className="m-2">Partner kiválasztása</p>
            </div>
            <div className="col-md-2">
              <select
                value={dropDown}
                onChange={dropdownChange}
                style={{ border: "none" }}
                className="m-2"
              >
                <option selected></option>
                {customerList.map((customer) => (
                  <option key={customer.id} value={customer.name}>
                    {customer.name}
                  </option>
                ))}
              </select>
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
                    <td>{appointment.surgeryName}</td>
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

export default ListCustomerAppointments;
