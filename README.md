![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Electron.js](https://img.shields.io/badge/Electron-191970?style=for-the-badge&logo=Electron&logoColor=white)
![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

# Web API with desktop app 

## Project Description

This is a real life project and the primary goal is to create an app for an occupational health business. The primary functions are:
<ul>
  <li>booking appointments</li>
  <li>managing customer information</li>
  <li>monitoring invoicing of examinations</li>
  <li>staff rostering</li>
</ul>

## Current Status

The development is still at a relatively early stage. Most work has been done on the backend but there are already fully functioning features as well. To try some of these you can do the following:
<ul>
  <li>use branch: 34-create-new-appointments-from-frontend</li>
  <li>in the menu bar click 'Előjegyzés' then</li>
  <ul>
    <li>pick 'Eger' from the 'Rendelő' dropdown and choose today's date</li>
    <li>pick 'Füzesabony' from the 'Rendelő' dropdown and choose tomorrow's date</li>
  </ul>
  <li>you can search for an already booked appointment of a patient under 'Páciens időpont keresése'</li>
  <ul>
    <li>start typing 'smith' in the search field and see the patients filtered</li>
  </ul>
  <li>you can list appointents by companies under 'Partner előjegyzéseinek listázása'</li>
  <li>statistics are available under 'Nem jelent meg statisztika' regarding missed appointments by companies</li>
</ul>

## Installation and Usage Instructions
<ol>
  <li>clone the project</li>
  <li>use branch: 34-create-new-appointments-from-frontend</li>
  <li>to download all frontend dependencies cd into the ElectronApp folder and run 'npm i'</li>
  <li>run the backend which will populate the SQL database with some dummy data</li>
  <li>start the desktop app by running 'npm run dev'</li>
</ol>  
