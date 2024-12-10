import axios from "axios";
import {useAsyncValue} from "react-router";

export const useAxios = ()=>{
    const api = axios.create({
        baseURL:'https://localhost:5001/api',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem('jwt'),
            'Current-Language': 'en-US',
        }
    });

    async function Get(url, availableCallback, failCallback)
    {
        return await api.get(url)
            .then(res => availableCallback(res))
            .catch(err => failCallback(err));
    }

    async function Post(url,data, availableCallback, failCallback) {
        await api.post(url, data)
            .then(res => availableCallback(res))
            .catch(err => failCallback(err));
    }

    async function Patch(url,data,availableCallback, failCallback) {
        return await api.patch(url, data)
            .then(res => availableCallback(res))
            .catch(err => failCallback(err));
    }

    async function Put(url,data, availableCallback, failCallback) {
        return await api.put(url,data)
            .then(res => availableCallback(res))
            .catch(err=>failCallback(err));
    }

    async function Delete(url,data, availableCallback, failCallback)
    {
        return await api.delete(url,data)
            .then(res => availableCallback(res))
            .catch(err => failCallback(err));
    }

    return {Get, Patch, Put, Delete, Post};
}