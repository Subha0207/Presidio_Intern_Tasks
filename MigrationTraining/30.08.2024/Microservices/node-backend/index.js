const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors')

const app = express();
app.use(cors());
app.use(express.json());

const MONGODB_URI="mongodb://mongodb:27017/testdb";

mongoose.connect(MONGODB_URI, { useNewUrlParser: true, useUnifiedTopology: true })
    .then(() => console.log('Connected to MongoDB sucessfully'))
    .catch(err => console.error('Failed to connect to MongoDB', err));

app.get('/api/check-db', (req, res) => {
  if (mongoose.connection.readyState === 1) {
    res.status(200).send('Database connection is successful');
  } else {
    res.status(500).send('Database connection failed');
  }
});

app.listen(5000, () => {
  console.log(`Server is running on port 5000`);
});