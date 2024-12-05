export const useLocalStorage = (key) => {

    function setValue(value) {
        localStorage.setItem(key, value);
    }

    function getValue(){
        return localStorage.getItem(key);
    }

    function clearValue() {
        localStorage.removeItem(key);
    }

    return {getValue, setValue, clearValue}
}