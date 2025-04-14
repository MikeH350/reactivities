import { List, ListItem, ListItemText, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import axios from "axios";

function App() {
  //Set the state
  const [activities, setActivities] = useState<Activity[]>([]);

  //For code you just want to run when the component mounts. Code is ran once. 
  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/activities')
      .then(response => setActivities(response.data))

    return () => {}
  }, []);

  return (
    <>
      <Typography variant='h3'>Reactivities</Typography>
      <List>  
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  )
}

export default App
