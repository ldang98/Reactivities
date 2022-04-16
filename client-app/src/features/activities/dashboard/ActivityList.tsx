import { observer } from "mobx-react-lite";
import React, { Fragment, SyntheticEvent, useState } from "react";
import { Link } from "react-router-dom";
import { Button, Header, Item, Label, Segment } from "semantic-ui-react";
import { Activity } from "../../../app/models/Activity";
import { useStore } from "../../../app/stores/store";
import ActivityListItem from "./ActivityListItem";

const ActivityList = () => {
  const { activityStore } = useStore();
  const { groupedActivites } = activityStore;

  return (
    <>
      {groupedActivites.map(([group, activities]) => (
        <Fragment key={group}>
          <Header sub color="teal">
            {group}
          </Header>

          {activities.map((activity) => (
            <ActivityListItem key={activity.id} activity={activity} />
          ))}
        </Fragment>
      ))}
    </>
  );
};

export default observer(ActivityList);
