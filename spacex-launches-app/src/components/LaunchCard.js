import React, { useState } from "react";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css"; // Import Bootstrap CSS
import { Modal, Button } from "react-bootstrap";
import LaunchDetails from "./LaunchDetails";

const LaunchCard = ({ launch }) => {
  const { id, name, success, date_utc, details, links } = launch;
  const imageSrc = links?.patch?.small || "default-image";
  const [launchDetails, setLaunchDetails] = useState(null);
  const [showModal, setShowModal] = useState(false);

  const fetchLaunchDetails = async () => {
    try {
      const response = await axios.get(
        `${process.env.REACT_APP_DOTNET_API_URL}/${id}`
      );
      setLaunchDetails(response.data);
      setShowModal(true);
    } catch (error) {
      console.error("Error fetching launch details:", error);
    }
  };

  const closeModal = () => {
    setShowModal(false);
  };

  return (
    <div className="launch-card">
      <div className="launch-header">
        <h2>{name}</h2>
        <span
          className={`launch-status ${
            success === true
              ? "success"
              : success === false
              ? "failure"
              : "unknown"
          }`}
        >
          {success === true
            ? "Success"
            : success === false
            ? "Failure"
            : "Unknown"}
        </span>
      </div>
      <p>Date: {new Date(date_utc).toLocaleDateString()}</p>
      <p>Details: {details || "Not Available"}</p>
      <p>
        Webcast:{" "}
        {links?.webcast ? (
          <a href={links.webcast} target="_blank" rel="noopener noreferrer">
            Watch on YouTube
          </a>
        ) : (
          "Not Available"
        )}
      </p>
      <p>
        Article:{" "}
        {links?.article ? (
          <a href={links.article} target="_blank" rel="noopener noreferrer">
            Read article
          </a>
        ) : (
          "Not Available"
        )}
      </p>
      <p>
        Wikipedia:{" "}
        {links?.wikipedia ? (
          <a href={links.wikipedia} target="_blank" rel="noopener noreferrer">
            Wikipedia
          </a>
        ) : (
          "Not Available"
        )}
      </p>
      {imageSrc !== "default-image" ? (
        <img src={imageSrc} alt="Launch Patch" className="launch-patch" />
      ) : (
        <div className="default-image">Image Not Available</div>
      )}
      <br />

      <div className="button-container">
        <button className="show-details-button" onClick={fetchLaunchDetails}>
          Show More Details
        </button>
      </div>

      <Modal
        show={showModal}
        onHide={closeModal}
        backdrop="static"
        dialogClassName="custom-modal"
      >
        <Modal.Header closeButton>
          <Modal.Title>Launch Details</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {launchDetails ? (
            <LaunchDetails launchDetails={launchDetails} />
          ) : (
            <p>Loading...</p>
          )}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={closeModal}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default LaunchCard;
