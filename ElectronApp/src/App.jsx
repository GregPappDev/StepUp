import { useEffect, useState } from "react";
import { Routes, Route, useNavigate } from "react-router-dom";
import HomeView from "./components/Home/HomeView";
import AppointmentView from "./components/Appointment/AppointmentView";

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
        <Route path="/" element={<HomeView />} />
      </Routes>
    </>
  );
}

export default App;
