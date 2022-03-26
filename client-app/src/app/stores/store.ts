import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";

interface Store {
  activityStore: ActivityStore;
}

//add instances of stores in here
export const store: Store = {
  activityStore: new ActivityStore(),
};

//pass the store to context
export const StoreContext = createContext(store);

//hook for components to use context
export function useStore() {
  return useContext(StoreContext);
}
