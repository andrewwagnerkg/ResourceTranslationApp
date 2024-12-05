import {useLocalStorage} from "./UseLocalStorage.js";
import {useAPI} from "./UseAPI.js";

export const useAuthProvider = ()=>{
    const {getValue, clearValue, setValue} = useLocalStorage('jwt');
    const {Login} = useAPI();

    function checkAuth()
    {
        return getValue();
    }

    async function onAvailableResponse(res)
    {
        if(res.status === 200)
        {
            setValue(await res.data);
        }
    }

    function onfaildResponse(err)
    {
        console.error(err.error);
    }

    async function signIn(login, password)
    {
        await Login(login, password, onAvailableResponse, onfaildResponse);
        console.log("request");
    }

    function signOut()
    {
        clearValue();
    }

    return {checkAuth, signIn, signOut};
}