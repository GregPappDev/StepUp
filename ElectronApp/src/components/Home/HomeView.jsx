import React from "react";
import logo from "/prevencio_logo.JPG?url";
import { Link, useNavigate } from "react-router-dom";

const HomeView = () => {
  const navigate = useNavigate();

  return (
    <div
      style={{
        display: "flex",
        height: "80vh",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <div class="row mw-100">
        <div class="column text-center">
          <img src={logo} class="img-fluid" alt="logo" />
        </div>
      </div>
    </div>
  );
};

export default HomeView;
