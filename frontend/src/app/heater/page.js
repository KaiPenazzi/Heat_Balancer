'use client'

import useSWR from 'swr'

const fetcher = (...args) => fetch(...args).then((res) => res.text())

export default function Home() {

    const { data: sdata, error } = useSWR('http://localhost:5169/status', fetcher, { refreshInterval: 1000 })

    if (error) console.log(error)

    return (
        <main className="flex min-h-screen flex-col items-center justify-between p-24">
            {sdata}
        </main>
    );
}
