﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using BitBucket.REST.API.Helpers;
using BitBucket.REST.API.Models.Enterprise;
using BitBucket.REST.API.Models.Standard;

namespace BitBucket.REST.API.Mappings.Converters
{
    public class EnterprisePullRequestTypeConverter :
        ITypeConverter<EnterprisePullRequest, PullRequest>,
        ITypeConverter<PullRequest, EnterprisePullRequest>
    {
        public PullRequest Convert(EnterprisePullRequest source, PullRequest destination, ResolutionContext context)
        {
            var pullRequest= new PullRequest()
            {
                Description = source.Description,
                Links = source.Links.MapTo<Links>(),
                Author = source.Author.User.MapTo<User>(),
                Title = source.Title,
                Source = source.Source.MapTo<Source>(),
                Destination = source.Destination.MapTo<Source>(),
                State = source.State.MapTo<PullRequestOptions>(),
                CreatedOn = source.CreatedOn.FromUnixTimeStamp().ToString(CultureInfo.InvariantCulture),
                UpdatedOn = source.UpdatedOn.FromUnixTimeStamp().ToString(CultureInfo.InvariantCulture),
                Id = source.Id,
                CommentsCount = source.Properties?.CommentsCount ?? 0,
                Participants = source.Participants.MapTo<List<Participant>>(),
                Reviewers = source.Reviewers.Select(x=>x.User).MapTo<List<UserShort>>().ToList()
            };

            pullRequest.Participants.AddRange(source.Reviewers.MapTo<List<Participant>>());//reviewers are part of participants in v2.0 - compatibility

            pullRequest.Links.Html = pullRequest.Links.Html ?? new Link() {Href = source.Links.Self.First().Href};
            return pullRequest;
        }

        public EnterprisePullRequest Convert(PullRequest source, EnterprisePullRequest destination, ResolutionContext context)
        {
            return new EnterprisePullRequest()
            {
                Description = source.Description,
                Title = source.Title,
                Source = source.Source.MapTo<EnterpriseBranchSource>(),
                Destination = source.Destination.MapTo<EnterpriseBranchSource>(),
                Id = source.Id,
            };
        }
    }
}