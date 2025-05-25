import axios, { AxiosRequestConfig, AxiosResponse, AxiosError } from "axios";
import { notify } from "./utility";
const ERE_API_DOMAIN = "http://localhost:5137";

type Method = "GET" | "POST" | "PATCH" | "DELETE";

interface HttpRequest {
  domain?: string;
  path: string;
  method: Method;
  payload?: Record<string, any>;
  headers?: Record<string, string>;
  params?: Record<string, string | number>;
}

class HttpClient {
  static async request<T = any>(
    options: HttpRequest
  ): Promise<AxiosResponse<T>> {
    const url = options.domain
      ? `${options.domain}${options.path}`
      : `${ERE_API_DOMAIN}${options.path}`;
    const config: AxiosRequestConfig = {
      method: options.method,
      url,
      headers: options.headers
        ? options.headers
        : {
            Authorization:
              "Bearer " + window.sessionStorage.getItem("ere-token"),
          },
      data: options.payload,
      params: options.params,
    };

    try {
      return await axios(config);
    } catch (error) {
      this.handleError(error);
      throw error;
    }
  }

  public static handleError(error: unknown): void {
    const axiosError = error as AxiosError;
    if (axiosError) {
      let status = axiosError?.status;
      let message = "Invalid Session";
      if (status !== 401) {
        message = axiosError.response?.data?.message;
      }
      return notify({
        message: message,
        stack: `${axiosError?.stack}`,
        duration: 5000,
      });
    }
  }

  static async get<T = any>(
    options: Omit<HttpRequest, "method" | "payload">
  ): Promise<AxiosResponse<T>> {
    return this.request<T>({ ...options, method: "GET" });
  }

  static async post<T = any>(
    options: Omit<HttpRequest, "method">
  ): Promise<AxiosResponse<T>> {
    return this.request<T>({ ...options, method: "POST" });
  }

  static async patch<T = any>(
    options: Omit<HttpRequest, "method">
  ): Promise<AxiosResponse<T>> {
    return this.request<T>({ ...options, method: "PATCH" });
  }

  static async delete<T = any>(
    options: Omit<HttpRequest, "method">
  ): Promise<AxiosResponse<T>> {
    return this.request<T>({ ...options, method: "DELETE" });
  }
}

export default HttpClient;
