import React from "react";
import { useState } from "react";

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
      {/* TITLE SECTION */}
      <div className="bg-primary">
        <div className="container-fluid">
          <h2 className="p-2 text-white m-0">Partner időpontjainak keresése</h2>
        </div>
      </div>

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
