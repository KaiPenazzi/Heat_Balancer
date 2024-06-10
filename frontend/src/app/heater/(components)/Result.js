'use client'

import useSWR from "swr";
import { Line } from 'react-chartjs-2';
import { useEffect, useState } from "react";

import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
} from 'chart.js';

ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
);

const fetcher = (...args) => fetch(...args).then((res) => res.json())

const transform = (data) => {
    let ret = []

    for (let i = 0; i < data.length; i++) {
        ret.push({
            heater: [],
            demand: [],
            labels: [],
            name: data[i].name
        })
        for (let j = 0; j < data[i].data.length; j++) {
            ret[i].heater.push(data[i].data[j][0])
            ret[i].demand.push(data[i].data[j][1])
            ret[i].labels.push("")
        }
    }

    return ret
}

export default function Result() {
    const { data, error } = useSWR('http://localhost:5169/sim/results', fetcher, { refreshInterval: 400 })
    if (error) console.log(error);

    const [data2, setData2] = useState([]);

    useEffect(() => {
        if (data != undefined) {
            let chartData = [];
            chartData = transform(data)



            setData2(() => {
                let data = []
                for (let i = 0; i < chartData.length; i++) {
                    data.push({
                        options: {
                            responsive: true,
                            plugins: {
                                legend: {
                                    position: 'top',
                                },
                                title: {
                                    display: true,
                                    text: chartData[i].name,
                                },
                            },
                        },
                        data: {
                            labels: chartData[i].labels,
                            datasets: [
                                {
                                    label: 'Demand',
                                    data: chartData[0].heater,
                                    borderColor: 'rgb(255, 99, 132)',
                                    backgroundColor: 'rgba(255, 99, 132, 0.5)',
                                },
                                {
                                    label: 'Produced',
                                    data: chartData[0].demand,
                                    borderColor: 'rgb(53, 162, 235)',
                                    backgroundColor: 'rgba(53, 162, 235, 0.5)',
                                },
                            ],
                        }
                    })
                }

                return data;
            })
        }
    }, [data])

    /*if (data2 == 0) {
        return (
            <>loading</>
        );
    }*/

    return (
        <main>
            {data2.map((data) => {
                return (
                    <Line options={data.options} data={data.data} />
                )
            })}
        </main >
    )
}
