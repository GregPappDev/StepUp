import React from "react";
import { useEffect } from "react";

async function getData() {
  console.log("before fetching");
  let response = await window.indexBridge.fetchData();
  console.log(`fetchData: ${response}`);
}

async function getApi() {
  console.log("before API fetching");
  let response = await window.indexBridge.fetchApi();
  console.log(`API Data: ${response}`);
}

const AppointmentView = () => {
  useEffect(() => {
    getData();
    getApi();
  }, []);

  return (
    <div class="container-fluid">
      <h1 class="mt-5 mb-2 text-primary">Előjegyzés</h1>
      <div class="container-fluid bg-light text-dark">
        <p class="p-3 mb-2 ">Időpontok szűrése</p>
      </div>

      <table class="table table-hover table-responsive">
        <thead>
          <tr>
            <th>Rendelő</th>
            <th>Dátum</th>
            <th>Időpont</th>
            <th style={{ minWidth: "200px" }}>Partner</th>
            <th>Dolgozó</th>
            <th>Vizsgálat típusa</th>
            <th>Megjegyzés</th>
            <th>Orvos</th>
            <th>Asszisztens</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Eger</td>
            <td>2023.09.20</td>
            <td>10:00</td>
            <td>Random Kft.</td>
            <td>Pécsi István</td>
            <td>előzetes</td>
            <td>06 30 1234567</td>
            <td>Dr. Orvos Antal</td>
            <td>Kovács Ilona</td>
          </tr>
          <tr>
            <td>Eger</td>
            <td>2023.09.20</td>
            <td>10:10</td>
            <td>Teszt Kft.</td>
            <td>Nagy Antal</td>
            <td>előzetes</td>
            <td>06 30 1234567</td>
            <td>Dr. Orvos Antal</td>
            <td>Kovács Ilona</td>
          </tr>
          <tr>
            <td>Füzesabony</td>
            <td>2023.09.21</td>
            <td>10:00</td>
            <td>Apple Inc.</td>
            <td>Joe Johnson</td>
            <td>időszakos</td>
            <td>06 30 1234567</td>
            <td>Dr. Kovács Attila</td>
            <td>Nagy Nóra</td>
          </tr>
          <tr>
            <td>Füzesabony</td>
            <td>2023.09.21</td>
            <td>10:10</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>Dr. Kovács Attila</td>
            <td>Nagy Nóra</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default AppointmentView;
