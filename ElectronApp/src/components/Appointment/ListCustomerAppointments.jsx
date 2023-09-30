import React from "react";
import { useState } from "react";
import PageTitle from "../Shared/PageTitle";

const ListCustomerAppointments = () => {
  const options = [
    { value: "", text: "" },
    { value: "Partner 1", text: "Partner 1" },
    { value: "NewPartner 2", text: "NewPartner 2" },
  ];

  const [dropDown, setDropDown] = useState(options[0].value);

  const dropdownChange = (event) => {
    console.log(event.target.value);
    setDropDown(event.target.value);
  };

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
                {options.map((option) => (
                  <option key={option.value} value={option.value}>
                    {option.text}
                  </option>
                ))}
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ListCustomerAppointments;
