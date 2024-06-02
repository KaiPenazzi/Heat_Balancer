import useSWR from "swr";

const fetcher = (...args) => fetch(...args).then((res) => res.json())

export default function Result() {
    const { data, error } = useSWR('http://localhost:5169/sim/results', fetcher, { refreshInterval: 400 })
    if (error) console.log(error);

    return (
        <main>
            {JSON.stringify(data)}
        </main>
    )
}
