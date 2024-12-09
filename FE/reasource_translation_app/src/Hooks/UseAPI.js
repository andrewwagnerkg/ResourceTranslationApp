import {useAxios} from "./UseAxios.js";

export const useAPI = ()=>{
    const {Post, Get, Put, Delete, Patch} = useAxios();

    const Login = async (userName, password, onAvailableResponse, onfaildResponse)=> {
        await Post(`/Auth/Authenticate?username=${userName}&password=${password}`,{}, onAvailableResponse, onfaildResponse);
    }

    return {Login}
}