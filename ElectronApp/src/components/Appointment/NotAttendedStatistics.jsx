import React from "react";
import { useState, useEffect } from "react";
import PageTitle from "../Shared/PageTitle";

const NotAttendedStatistics = () => {
  const [list, setList] = useState([]);

  useEffect(() => {
    async function getApi() {
      let response = await window.indexBridge.fetchNotAttended();
      setList(response);
    }

    getApi();
  }, []);

  console.log(`statisztika: ${list}`);

  return (
    <div>
      <PageTitle title={'"Nem jelent meg" statisztika'} />
      <div className="m-5 bg-white"></div>
      <div className="container ">
        <table
          className="table table-hover table-responsive "
          style={{ maxWidth: "500px" }}
        >
          <thead>
            <tr>
              <th>Partner</th>
              <th>Statisztika</th>
            </tr>
          </thead>
          <tbody>
            {list &&
              list.map((item) => {
                return (
                  <tr key={item.customerName}>
                    <td>{item.customerName}</td>
                    <td>{item.count}</td>
                  </tr>
                );
              })}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default NotAttendedStatistics;
