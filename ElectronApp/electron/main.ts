import { app, BrowserWindow, ipcMain, Menu } from "electron";
import path from "node:path";
import fetch from "node-fetch";
import axios from "axios";

// The built directory structure
//
// ├─┬─┬ dist
// │ │ └── index.html
// │ │
// │ ├─┬ dist-electron
// │ │ ├── main.js
// │ │ └── preload.js
// │
process.env.DIST = path.join(__dirname, "../dist");
process.env.VITE_PUBLIC = app.isPackaged
  ? process.env.DIST
  : path.join(process.env.DIST, "../public");

let win: BrowserWindow | null;
// 🚧 Use ['ENV_NAME'] avoid vite:define plugin - Vite@2.x
const VITE_DEV_SERVER_URL = process.env["VITE_DEV_SERVER_URL"];

function createWindow() {
  win = new BrowserWindow({
    icon: path.join(process.env.VITE_PUBLIC, "prevencio_icon.JPG"),
    width: 1920,
    height: 1080,
    webPreferences: {
      nodeIntegration: false,
      contextIsolation: true,
      preload: path.join(__dirname, "preload.js"),
    },
  });

  // Test active push message to Renderer-process.
  win.webContents.on("did-finish-load", () => {
    win?.webContents.send("main-process-message", new Date().toLocaleString());
  });

  const menu = Menu.buildFromTemplate(template);
  Menu.setApplicationMenu(menu);

  //win.webContents.openDevTools();

  if (VITE_DEV_SERVER_URL) {
    win.loadURL(VITE_DEV_SERVER_URL);
  } else {
    // win.loadFile('dist/index.html')
    win.loadFile(path.join(process.env.DIST, "index.html"));
  }
}

const template: Electron.MenuItemConstructorOptions[] = [
  {
    label: "File",
    submenu: [
      {
        label: "Kezdőoldal",
        click: () => pageNavigation("/"),
      },
      { label: "Frissítés", click: () => win?.reload() },
      { role: "minimize" },
      { role: "quit" },
    ],
  },
  {
    label: "Előjegyzés",
    submenu: [
      {
        label: "Előjegyzés",
        click: () => pageNavigation("/appointment"),
      },
      { type: "separator" },
      { label: "Időpontok generálása" },
      { label: "Egyedi időpont beszúrása" },
      { type: "separator" },
      {
        label: "Páciens időpont keresése",
        click: () => pageNavigation("/patientappointments"),
      },
      {
        label: "Partner előgyezéseinek listázása",
        click: () => pageNavigation("/customerappointments"),
      },
      { type: "separator" },
      {
        label: '"Nem jelent meg" statisztika',
        click: () => pageNavigation("/notattended"),
      },
    ],
  },
  {
    label: "Partnerek",
    submenu: [{ label: "Partner keresése" }, { label: "Új partner rögítése" }],
  },
  {
    label: "Számlázás",
    submenu: [
      { label: "Számlázásra váró vizsgálatok" },
      { label: "Időszakos számlák listázása" },
    ],
  },
  {
    label: "Admin",
    submenu: [{ role: "toggleDevTools" }],
  },
];

// Quit when all windows are closed, except on macOS. There, it's common
// for applications and their menu bar to stay active until the user quits
// explicitly with Cmd + Q.
app.on("window-all-closed", () => {
  if (process.platform !== "darwin") {
    app.quit();
    win = null;
  }
});

app.on("activate", () => {
  // On OS X it's common to re-create a window in the app when the
  // dock icon is clicked and there are no other windows open.
  if (BrowserWindow.getAllWindows().length === 0) {
    createWindow();
  }
});

app.whenReady().then(createWindow);

ipcMain.handle("fetchCustomers", async () => {
  process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = "0";
  const response = await fetch(
    "https://localhost:7076/api/Customer/GetNotDeleted"
  );
  const body = await response.text();
  console.log(body);
  return body;
});

ipcMain.handle("fetchApi", async () => {
  process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = "0";
  const response = await fetch("https://localhost:7076/api/Appointment");
  const body = await response.text();
  return body;
});

ipcMain.handle("fetchExaminationType", async () => {
  process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = "0";
  const response = await fetch(
    "https://localhost:7076/api/ExaminationType/GetNotDeleted"
  );
  const body = await response.text();
  return body;
});

ipcMain.handle("fetchNotAttended", async () => {
  process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = "0";
  const response = await fetch(
    "https://localhost:7076/api/Appointment/GetNotAttended"
  );
  const body = await response.text();
  return body;
});

// ipcMain.handle("fetchAppointments", async () => {
//   process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = "0";
//   const response = await axios.get("https://localhost:7076/api/Appointment");
//   console.log(response);
//   return response;
// });

function pageNavigation(path: string) {
  win?.webContents.send("navi", path);
}
