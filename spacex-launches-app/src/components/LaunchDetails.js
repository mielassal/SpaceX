import React from "react";

const LaunchDetails = ({ launchDetails }) => {
  const formatDate = (date) => {
    if (!date) {
      return "Not Available";
    }

    const formattedDate = new Date(date).toLocaleDateString("en-US", {
      year: "numeric",
      month: "long",
      day: "numeric",
    });

    return formattedDate;
  };
  return (
    <div className="launch-details">
      <div className="launch-header">
        <h2 className="launch-name">{launchDetails.name}</h2>
        <span
          className={`launch-status ${
            launchDetails.success === true
              ? "success"
              : launchDetails.success === false
              ? "failure"
              : "unknown"
          }`}
        >
          {launchDetails.success === true
            ? "Success"
            : launchDetails.success === false
            ? "Failure"
            : "Unknown"}
        </span>
      </div>
      <div>
        <p className="details-label">Details:</p>
        <p>{launchDetails.details}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Success:</p>
        <p>{launchDetails.success ? "Yes" : "No"}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Upcoming:</p>
        <p>{launchDetails.upcoming ? "Yes" : "No"}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Date:</p>
        <p>{formatDate(launchDetails.date_Utc)}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Static Fire Date:</p>
        <p>{formatDate(launchDetails.static_Fire_Date_Utc)}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Flight Number:</p>
        <p>{launchDetails.flight_Number}</p>
      </div>
      <div className="details-row">
        <p className="details-label">TBD:</p>
        <p>{launchDetails.tbd ? "Yes" : "No"}</p>
      </div>
      <div className="details-row">
        <p className="details-label">NET:</p>
        <p>{launchDetails.net ? "Yes" : "No"}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Window:</p>
        <p>{launchDetails.window}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Rocket Name:</p>
        <p>{launchDetails.rocketName}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Rocket Country:</p>
        <p>{launchDetails.rocketCountry}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Rocket Company:</p>
        <p>{launchDetails.rocketCompany}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Launch Pad:</p>
        <p>{launchDetails.launchPadName}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Launch Pad Name:</p>
        <p>{launchDetails.launchPadFullName}</p>
      </div>
      <div className="details-row">
        <p className="details-label">Launch Pad Region:</p>
        <p>{launchDetails.launchPadRegion}</p>
      </div>
    </div>
  );
};

export default LaunchDetails;
