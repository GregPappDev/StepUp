import { useEffect, useState } from "react";
import { Routes, Route, useNavigate } from "react-router-dom";
import HomeView from "./components/Home/HomeView";
import AppointmentView from "./components/Appointment/AppointmentView";
import ListCustomerAppointments from "./components/Appointment/ListCustomerAppointments";
import ListPatientAppointments from "./components/Appointment/ListPatientAppointments";
import NotAttendedStatistics from "./components/Appointment/NotAttendedStatistics";

function App() {
  const [path, setPath] = useState("/");

  const navigate = useNavigate();

  useEffect(() => {
    navigate(path);
  }, [path]);

  window.ipcRenderer.once("navi", (_event, message) => {
    console.log(message);
    console.log("navigáció beállítása");
    setPath(message);
  });

  return (
    <>
      <Routes>
        <Route path="/appointment" element={<AppointmentView />} />
        <Route
          path="/customerappointments"
          element={<ListCustomerAppointments />}
        />
        <Route
          path="/patientappointments"
          element={<ListPatientAppointments />}
        />
        <Route path="/notattended" element={<NotAttendedStatistics />} />
        <Route path="/" element={<HomeView />} />
      </Routes>
    </>
  );
}

export default App;
