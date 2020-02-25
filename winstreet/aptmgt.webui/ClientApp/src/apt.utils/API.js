import axios from "axios";
import authService from 'components/Authorization/AuthorizeService.js';

export default axios.create({
  baseURL: "https://localhost:5001/api",
  responseType: "json"
});