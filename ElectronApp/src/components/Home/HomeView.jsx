import React from "react";
import logo from "/prevencio_logo.JPG?url";

const HomeView = () => {
  return (
    <div
      style={{
        display: "flex",
        height: "80vh",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <div className="row mw-100">
        <div className="column text-center">
          <img src={logo} className="img-fluid" alt="logo" />
        </div>
      </div>
    </div>
  );
};

export default HomeView;
