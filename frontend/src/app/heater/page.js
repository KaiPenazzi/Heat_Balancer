'use client'

import useSWR from 'swr'

const fetcher = (...args) => fetch(...args).then((res) => res.json())

export default function Home() {

    const { data: heaters = [], error } = useSWR('http://localhost:5169/status', fetcher, { refreshInterval: 1000 })

    //console.log(JSON.stringify(heaters));

    if (error) console.log(error)

    //return (<main></main>);

    return (
        <main className="flex flex-col items-center p-24">
            <table className="table-auto">
                <thead>
                    <tr>
                        <th className="">Name</th>
                        <th>Demand</th>
                    </tr>
                </thead>
                <tbody>
                    {heaters.map((heater) => {
                        return (<tr>
                            <td> {heater.name} </td>
                            <td> {heater.demand} </td>
                        </tr>)
                    })}
                </tbody>
            </table>
        </main>
    );
}
