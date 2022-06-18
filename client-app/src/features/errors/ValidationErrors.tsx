import React from "react";
import { Message } from "semantic-ui-react";

interface Props {
  errors: any;
}
function ValidationErrors({ errors }: Props) {
  return (
    <Message error>
      {errors && (
        <Message.List>
          {errors.map((err: any, idx: any) => (
            <Message.Item key={idx}>{err}</Message.Item>
          ))}
        </Message.List>
      )}
    </Message>
  );
}

export default ValidationErrors;
