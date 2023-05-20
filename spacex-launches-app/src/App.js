import React, { useEffect, useState } from "react";
import axios from "axios";
import LaunchCard from "./components/LaunchCard";
import "./App.css";

const App = () => {
  const [launches, setLaunches] = useState([]);

  useEffect(() => {
    const fetchLaunches = async () => {
      try {
        const response = await axios.get(process.env.REACT_APP_SPACEX_API_URL);
        setLaunches(response.data);
      } catch (error) {
        console.error("Error fetching launches:", error);
      }
    };

    fetchLaunches();
  }, []);

  return (
    <div className="app">
      <header className="header-fixed">
        <div className="header-limiter">
          <h1>
            SpaceX<span>Launches</span>
          </h1>
        </div>
      </header>
      {launches.map((launch) => (
        <LaunchCard key={launch.id} launch={launch} />
      ))}
    </div>
  );
};

export default App;
