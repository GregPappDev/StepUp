import React from "react";

const PageTitle = ({ title }) => {
  return (
    <div className="bg-primary">
      <div className="container-fluid">
        <h2 className="p-2 text-white m-0">{title}</h2>
      </div>
    </div>
  );
};

export default PageTitle;
