import {useAxios} from "./UseAxios.js";

export const useAPI = ()=>{
    const {Post, Get, Put, Delete, Patch} = useAxios();

    const Login = async (userName, password, onAvailableResponse, onfaildResponse)=> {
        await Post(`/Auth/Authenticate?username=${userName}&password=${password}`,{}, onAvailableResponse, onfaildResponse);
    }
    const GetLocales = async (onAvailableResponse, onfailedResponse)=> {
        await Get(`/Locale/GetAllLocales`, onAvailableResponse, onfailedResponse);
    }

    const AddLanguage = async (language, onAvailableResponse, onfailedResponse)=> {
        await Post(`/Locale/CreateLocale`, {"Code":language.Code, "Name":language.Name}, onAvailableResponse, onfailedResponse);
    }


    return {Login, GetLocales, AddLanguage}
}