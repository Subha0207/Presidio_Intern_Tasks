import { useEffect, useState } from 'react';
import axios from 'axios';
import React from 'react';

function App() {
  const [dbStatus, setDbStatus] = useState(null);

  useEffect(() => {
    axios.get('http://localhost:5000/api/check-db')
      .then(response => setDbStatus(response.data))
      .catch(error => setDbStatus('Error: ' + error.message));
  }, []);

  return (
    <div className="App">
      <h1>{dbStatus ? dbStatus : 'Checking database connection...'}</h1>
    </div>
  );
}

export default App;
