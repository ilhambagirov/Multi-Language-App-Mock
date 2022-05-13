import axios, {AxiosResponse } from "axios";
import { News } from "../models/News";

axios.defaults.baseURL = "https://localhost:44382/api";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const request = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(id: string, body: {}) => axios.put<T>(id, body).then(responseBody),
  delete: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};
const NewsService = {
  getAll: (lang : string) => request.get<News[]>(`/News/${lang}`),
};


const agent = {
    NewsService,
};
export default agent;