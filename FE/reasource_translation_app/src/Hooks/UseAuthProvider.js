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

    async function signIn(login, password, onAvailableResponseExternal, onFailResponse)
    {
        await Login(login, password, async (res) => {await onAvailableResponse(res); await onAvailableResponseExternal()}, onFailResponse);
    }

    function signOut()
    {
        clearValue();
    }

    return {checkAuth, signIn, signOut};
}