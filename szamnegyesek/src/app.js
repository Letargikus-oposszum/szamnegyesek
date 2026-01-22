const express = require("express");
const cors = require("cors");

const app = express();
app.use(cors());
app.use(express.json());

let fours = [];

app.get("/fours", (req, res) => {
  res.json(fours);
});

app.get("/fours/:id", (req, res) => {
  const id = Number(req.params.id);
  if (fours[id] === undefined) {
    return res.status(404).send("Not found");
  }
  res.json(fours[id]);
});

app.post("/fours", (req, res) => {
  const data = req.body;

  if (!Array.isArray(data) || data.length !== 4) {
    return res.status(400).send("Invalid data");
  }

  if (fours.some(f => JSON.stringify(f) === JSON.stringify(data))) {
    return res.status(400).send("Already exists");
  }

  fours.push(data);
  res.json({ id: fours.length - 1, data });
});

app.listen(3000, () => {
  console.log("Server running on http://localhost:3000");
});
