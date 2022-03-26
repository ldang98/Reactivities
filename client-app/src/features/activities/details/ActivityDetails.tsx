import React from "react";
import { act } from "react-dom/test-utils";
import { Button, Card, Icon, Image } from "semantic-ui-react";
import LoadingComponents from "../../../app/layout/LoadingComponents";
import { useStore } from "../../../app/stores/store";

const ActivityDetails = () => {
  const { activityStore } = useStore();

  //giveselectedActivity the name activity
  const { selectedActivity: activity } = activityStore;

  if (!activity) return <LoadingComponents />;
  return (
    <Card fluid sticky>
      <Image src={`/assets/categoryImages/${activity.category}.jpg`} />
      <Card.Content>
        <Card.Header>{activity.title}</Card.Header>
        <Card.Meta>
          <span>{activity.date}</span>
        </Card.Meta>
        <Card.Description>{activity.description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths="2">
          <Button
            onClick={() => {
              activityStore.openForm(activity.id);
            }}
            basic
            color="blue"
            content="Edit"
          />
          <Button
            onClick={activityStore.cancelSelectedActivity}
            basic
            color="grey"
            content="Cancel"
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
};

export default ActivityDetails;
