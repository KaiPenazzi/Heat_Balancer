'use client'

import useSWR from 'swr'
import Button from './(components)/Button'
import AddDemand from './(components)/AddDemand'
import AddHeater from './(components)/AddHeater'
import Result from './(components)/Result'

const fetcher = (...args) => fetch(...args).then((res) => res.json())

function Remove(id) {
    console.log(id);
    fetch('http://localhost:5169/heater/remove?ID=' + id, {
        method: 'post'
    });

}

function StartSimulation(time) {
    fetch('http://localhost:5169/sim/start?Time=' + time, {
        method: 'post'
    })
}



export default function Home() {
    const { data: heaters = [], error } = useSWR('http://localhost:5169/status', fetcher, { refreshInterval: 400 })
    if (error) console.log(error)

    return (
        <main className="flex flex-col items-center p-24">
            <Button onClick={() => StartSimulation(200)}>Start Simulation</Button>
            <AddHeater></AddHeater>
            <table className="table-auto">
                <thead>
                    <tr>
                        <th className="">Name</th>
                        <th>Demand</th>
                        <th>Remove</th>
                        <th>Demand</th>
                    </tr>
                </thead>
                <tbody>
                    {heaters.map((heater) => {
                        return (<tr key={heater.id}>
                            <td> {heater.name} </td>
                            <td> {heater.demand} </td>
                            <td><Button onClick={() => Remove(heater.id)}>Remove</Button></td>
                            <td><AddDemand id={heater.id}></AddDemand></td>
                        </tr>)
                    })}
                </tbody>
            </table>
            <Result></Result>
        </main>
    );
}
