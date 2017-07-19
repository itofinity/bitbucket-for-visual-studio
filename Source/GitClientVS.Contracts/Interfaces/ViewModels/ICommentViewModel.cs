﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GitClientVS.Contracts.Models.GitClientModels;
using GitClientVS.Contracts.Models.Tree;
using ReactiveUI;

namespace GitClientVS.Contracts.Interfaces.ViewModels
{
    public interface ICommentViewModel : IViewModelWithErrorMessage
    {
        ReactiveCommand ReplyCommentCommand { get; }
        ReactiveCommand EditCommentCommand { get; }
        ReactiveCommand DeleteCommentCommand { get; }
        ReactiveCommand AddCommentCommand { get; }
        string AddCommentText { get; set; }
        string AddInlineCommentText { get; set; }

        List<ICommentTree> CommentTree { get; }
        int CommentsCount { get; }
        long PullRequestId { get; }
        List<ICommentTree> InlineCommentTree { get; }

        Task UpdateComments(long pullRequestId);
    }
}