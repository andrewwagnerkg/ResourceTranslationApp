import {useLocalStorage} from "./UseLocalStorage.js";

export const useAuthProvider = ()=>{
    const {getValue, clearValue, setValue} = useLocalStorage('jwt');

    function checkAuth()
    {
        return getValue();
    }

    function signIn(login, password)
    {
        //api login
        setValue(`${login}:${password}`);
    }

    function signOut()
    {
        //api logout
        clearValue();
    }

    return {checkAuth, signIn, signOut};
}