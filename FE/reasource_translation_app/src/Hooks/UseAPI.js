import {useAxios} from "./UseAxios.js";

export const useAPI = ()=>{
    const {Post, Get, Put, Delete, Patch} = useAxios();

    const Login = async (userName, password, onAvailableResponse, onfaildResponse)=> {
        await Post(`/Auth/Authenticate?username=${userName}&password=${password}`,{}, onAvailableResponse, onfaildResponse);
    }
    const GetLocales = async (onAvailableResponse, onfailedResponse)=> {
        await Get(`/Locale/GetAllLocales`, onAvailableResponse, onfailedResponse);
    }

    const AddLanguage = async (languageModel, onAvailableResponse, onfailedResponse)=> {
        await Post(`/Locale/CreateLocale`, {"Code":languageModel.Code, "Name":languageModel.Name}, onAvailableResponse, onfailedResponse);
    }

    const DeleteLanguage = async (languageId, onAvailableResponse, onfailedResponse)=> {
        await Delete(`/Locale/DeleteLocale/?id=${languageId}`, {}, onAvailableResponse, onfailedResponse);
    }


    return {Login, GetLocales, AddLanguage, DeleteLanguage}
}