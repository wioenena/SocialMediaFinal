import { useEffect, useState } from "react";
import GirisYap from "./Components/GirisYap";
import Posts from "./Components/Posts";

function App() {
  const [account, setAccount] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      if (account === null) {
        fetch(`${import.meta.env.VITE_API_URL}/auth/account/@me`, {
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
          },
        }).then(async (res) => {
          const data = await res.json();
          setAccount(data.account);
          setLoading(false);
        });
      }
    } else {
      setLoading(false);
    }
  }, [account]);

  if (loading) {
    return (
      <div className="h-full w-screen flex flex-col items-center justify-center text-white">
        <div className="h-screen w-screen animate-pulse bg-neutral-800 rounded-lg shadow-lg flex items-center justify-center" />
      </div>
    );
  }

  if (account === null && !loading) {
    return (
      <div className="h-full w-screen flex flex-col items-center justify-center text-white">
        <GirisYap setAccount={setAccount} />
      </div>
    );
  }

  return (
    <div className="h-full w-screen flex flex-col items-center justify-center text-white">
      <Posts account={account} />
    </div>
  );
}

export default App;
