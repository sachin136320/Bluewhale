import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:5001/api1",
  responseType: "json"
});