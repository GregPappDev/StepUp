import { useState } from "react";
import { Routes, Route, Link, useNavigate, Navigate } from "react-router-dom";
import reactLogo from "./assets/react.svg";
import viteLogo from "/electron-vite.animate.svg";
import HomeView from "./components/Home/HomeView";
import AppointmentView from "./components/Appointment/AppointmentView";
import "bootstrap/dist/css/bootstrap.css";
//import "./App.css";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <Routes>
        <Route path="/appointment" element={<AppointmentView />} />
        <Route path="/" element={<HomeView />} />
      </Routes>
    </>
  );
}

export default App;
