import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import CommonStore from "./commonStore";

interface Store {
  activityStore: ActivityStore;
  commonStore: CommonStore;
}

//add instances of stores in here
export const store: Store = {
  activityStore: new ActivityStore(),
  commonStore: new CommonStore(),
};

//pass the store to context
export const StoreContext = createContext(store);

//hook for components to use context
export function useStore() {
  return useContext(StoreContext);
}
