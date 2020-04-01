export interface UserCommentModel {
  id?: number;
  creatDate?: string;
  name: string;
  email: string;
  comment: string;
  userAgentInfo?: string;
  isRead?: boolean;
}
