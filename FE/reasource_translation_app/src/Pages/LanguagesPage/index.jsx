import {useEffect, useState} from "react";
import {useAPI} from "../../Hooks/UseAPI.js";

function ResourcesPage() {
const {GetResources} = useAPI();
const [locales, setLocales] = useState([]);

    useEffect(()=>{
        fetchData();
    }, []);

    async function onAvailable(res) {
        console.log("OK");
        console.log(res);
        setLocales(res.data);
    }

    async function onError(error) {
        console.log(error);
    }

    const fetchData = async () => {
        await GetResources(onAvailable, onError);
    }

    return (
        <>
            <ul>
        {locales.map((x) => (<li key={x.id}>{x.name}</li>))}
            </ul>
        </>
    )
}

export default ResourcesPage;